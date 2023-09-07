function triggerDownload(dataUrl, fileName) {
    const link = document.getElementById('downloadLink');
    link.href = dataUrl;
    link.download = fileName;
    link.click();
}