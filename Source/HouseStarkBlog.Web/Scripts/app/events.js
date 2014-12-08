var app = app || {};

app.events = (function () {
    function addPost() {
        location.href = '/Post/Create';
    }

    function createPost() {
        var url = app.service.url + '/Posts';
        var data = app.utils.getFormData('#create-post-form');
        console.log(data);
        app.ajaxRequester.post('http://localhost:6859/Posts', data).then(function (data) {
            console.log('ok');
        }, function (err) {
            console.error(err);
        });
    }

    function editPost() {
        var path = location.pathname.replace('Details', 'Edit');
        location.href = path;
    }

    function updatePost() {
        console.log(location.pathname);
    }

    function deletePost() {
        var path = location.pathname.replace('Details', 'Delete');
        location.href = path;
    }

    function replyPost() {
        app.renderer.renderReplyForm('#reply-form');
    }

    return {
        addPost: addPost,
        createPost: createPost,
        editPost: editPost,
        updatePost: updatePost,
        deletePost: deletePost,
        replyPost: replyPost
    };
})();