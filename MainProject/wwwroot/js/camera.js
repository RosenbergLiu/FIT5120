async function initializeCamera(videoElementId) {
    const videoElement = document.getElementById(videoElementId);

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        try {
            const stream = await navigator.mediaDevices.getUserMedia({ video: true });
            videoElement.srcObject = stream;
            return true;
        } catch (err) {
            console.error("An error occurred: " + err);
            return false;
        }
    }
    return false;
}

function captureImage(videoElementId, canvasElementId) {
    const videoElement = document.getElementById(videoElementId);
    const canvasElement = document.getElementById(canvasElementId);

    const context = canvasElement.getContext('2d');
    context.drawImage(videoElement, 0, 0, canvasElement.width, canvasElement.height);

    return canvasElement.toDataURL('image/png');
}