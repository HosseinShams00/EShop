function slugify(titleStr) {

    // https://github.com/seyedalifazel/js-slugify-with-persian-support
    titleStr = titleStr.replace(/^\s+|\s+$/g, '');
    titleStr = titleStr.toLowerCase();
    //persian support
    titleStr = titleStr.replace(/[^a-z0-9_\s-ءاأإآؤئبتثجحخدذرزسشصضطظعغفقكلمنهويةى]#u/, '')
        // Collapse whitespace and replace by -
        .replace(/\s+/g, '-')
        // Collapse dashes
        .replace(/-+/g, '-');

    document.getElementById("Slug").value = titleStr;
}

function ImagePreviewer(fileInput, imageId) {

    const reader = new FileReader();
    reader.readAsDataURL(fileInput.files[0]);
    reader.addEventListener("load", () => {
   
        document.getElementById(imageId).classList.remove("d-none");
        document.getElementById(imageId).classList.add("d-block");
        document.getElementById(imageId).getElementsByTagName("img")[0].src = reader.result;

    }, false);

}


$.validator.addMethod('maxFileSize', function (value, element, params) {
    const maxSize = element.getAttribute("maxFileSize-value") * 1024 * 1024;
    if (element.files[0].size > maxSize)
        return false;
    else
        return true;
});
$.validator.unobtrusive.adapters.addBool('maxFileSize');
