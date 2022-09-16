function slugify(titleStr)
{

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

function ImagePreviewer(src , imageId)
{
    if (src != "") {
        document.getElementById(imageId).classList.remove("d-none");
        document.getElementById(imageId).classList.add("d-block");
        document.getElementById(imageId).getElementsByTagName("img")[0].src = src;
    }
    else {
        document.getElementById(imageId).classList.remove("d-block");
        document.getElementById(imageId).classList.add("d-none");
        document.getElementById(imageId).getElementsByTagName("img")[0] = "";
    }

}