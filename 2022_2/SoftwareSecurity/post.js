function Submit() {
    var titleData = retrieveData()
    console.log(titleData);
}

function retrieveData() {
    var name1 = document.getElementById("title").value;
    var myTextarea = tinymce.get("myTextarea").getContent();

    var arr = [name1, myTextarea];
    console.log(myTextarea);
    return arr;
}