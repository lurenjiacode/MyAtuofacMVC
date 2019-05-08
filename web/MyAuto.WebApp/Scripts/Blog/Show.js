//hljs.initHighlightingOnLoad();

$(document).ready(function () {
    //var blogid = @ViewBag.Title;
    //alert(blogid);
    //$(function () {
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "GetBlog",
        data: "{ \"BlogID\":\"" + blogid + "\" }",
        success: function (result) {
            document.getElementById("blogcontent").innerHTML = result;
        }
    });
});
