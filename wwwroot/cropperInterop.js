let cropper;

window.cropperInterop = {
    initCropper: (imageId) => {
        const image = document.getElementById(imageId);
        if (!image) return;
        cropper = new Cropper(image, {
            aspectRatio: 1,
            viewMode: 1,
            autoCropArea: 1
        });
    },
    getCroppedImage: () => {
        if (!cropper) return null;
        const canvas = cropper.getCroppedCanvas({ width: 256, height: 256 });
        return canvas.toDataURL("image/jpeg");
    },
    destroyCropper: () => {
        if (cropper) {
            cropper.destroy();
            cropper = null;
        }
    }
};
