let activeStream = null; // Keep track of active media stream

async function initializeCamera(videoElementId) {
    const videoElement = document.getElementById(videoElementId);

    if (videoElement === null) {
        console.error("Video element not found");
        return false;
    }

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        try {
            // Stop active stream if there is one
            if (activeStream) {
                activeStream.getTracks().forEach(track => track.stop());
            }

            const stream = await navigator.mediaDevices.getUserMedia({ video: true });
            activeStream = stream;
            videoElement.srcObject = stream;

            // Explicitly play the video when the user media is obtained
            videoElement.onloadedmetadata = function(e) {
                videoElement.play();
            };

            return true;
        } catch (err) {
            console.error("An error occurred: " + err);
            return false;
        }
    } else {
        console.warn("Your browser does not support navigator.mediaDevices.getUserMedia");
        return false;
    }
}

async function captureAndAnalyzeFrame(videoElementId, canvasElementId, apiKey) {
    const videoElement = document.getElementById(videoElementId);
    const canvasElement = document.getElementById(canvasElementId);
    const ctx = canvasElement.getContext("2d");

    if (videoElement.readyState === videoElement.HAVE_ENOUGH_DATA) {
        canvasElement.width = videoElement.videoWidth;
        canvasElement.height = videoElement.videoHeight;
        ctx.drawImage(videoElement, 0, 0, videoElement.videoWidth, videoElement.videoHeight);

        const imageDataUrl = canvasElement.toDataURL("image/png").split(",")[1]; // Get Base64 image data

        

        // Prepare API payload
        const payload = {
            "requests": [
                {
                    "image": {
                        "content": imageDataUrl
                    },
                    "features": [
                        {
                            "type": "TEXT_DETECTION"
                        }
                    ]
                }
            ]
        };

        // Call Google Vision API
        const response = await fetch("https://vision.googleapis.com/v1/images:annotate?key=" + apiKey, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(payload)
        });

        if (activeStream) {
            activeStream.getTracks().forEach(track => track.stop());
            activeStream = null;
        }

        if (response.ok) {
            const data = await response.json();
            if (data.responses && data.responses[0] && data.responses[0].textAnnotations && data.responses[0].textAnnotations[0]) {
                const textAnnotations = data.responses[0].textAnnotations[0].description || "No text detected";
                return textAnnotations;
            }
            else {
                return null;
            }
        } else {
            const errMessage = await response.text();
            throw new Error("Failed to call API: " + errMessage);
        }
    }
    return null;
}
