
var config = {
    extraPlugins: 'codesnippet',
    codeSnippet_theme: 'zenburn',
    height: 356
};
var BlogContent = CKEDITOR.replace('blogContent', config);

function ass() {
    var title = $("#title").val();
    var creator = $("#creator").val();
    var keywords = $("#keywords").val();
    var blogContentHtml = BlogContent.document.getBody().getHtml(); //取包含html代码的值
    var content = $.base64.encode(blogContentHtml);
    $(function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "AddBlog",
            data: "{ \"Title\":\"" + title + "\"," +
                "\"Keywords\":\"" + keywords + "\"," +
                "\"Creator\":\"" + creator + "\"," +
                "\"BlogContent\":\"" + content + "\" }",
            success: function (result) {
                alert(title + "添加完成");
                window.location.href = "";
            }
        });
    });
}
