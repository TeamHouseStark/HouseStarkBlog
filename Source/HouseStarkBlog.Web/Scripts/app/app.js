var app = app || {};

(function () {
  app.service = (function () {
    var baseUrl = 'http://service-teamStark.somee.com';

    return {
      url: baseUrl
    };
  })();

  $(function assignEvents() {
    $('#addPostBtn').click(app.events.addPost);
    $('#create-post-button').click(app.events.createPost);
    $('#edit-post-btn').click(app.events.editPost);
    $('#delete-post-btn').click(app.events.deletePost);
    $('#update-post-btn').click(app.events.updatePost);
    $('#reply-post-btn').click(app.events.replyPost);
    $('#comment-post-btn').click(app.events.commentPost);
  });

})();