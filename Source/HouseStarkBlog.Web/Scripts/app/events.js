var app = app || {};

app.events = (function () {
  function addPost() {
    location.href = '/Post/Create';
  }

  function createPost() {
    var url = app.service.url + '/Posts';
    var data = app.utils.getFormData('#create-post-form');
    app.ajaxRequester.post(url, data).then(function (data) {
      noty({
        type: 'success',
        text: 'Post added.',
        layout: 'center',
        callback: {
          onClose: function () {
            location.href = '/';
          }
        }
      });
    }, function (err) {
      noty({
        type: 'error',
        text: 'Something went wrong try again later.',
        layout: 'center',
        callback: {
          onCloseClick: function () {
            history.back();
          }
        }
      });
    });
  }

  function editPost() {
    var path = location.pathname.replace('Details', 'Edit');
    location.href = path;
  }

  function updatePost() {
    
  }

  function deletePost() {
    var path = location.pathname.replace('Details', 'Delete');
    location.href = path;
  }

  function replyPost() {
    $('#reply-form').toggle();
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