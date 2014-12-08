var app = app || {};

app.renderer = (function () {
    //TODO refactor
  function renderPosts(posts, container) {
    var url = location.origin + '/Post/Details/';
    if (posts.length === 0) {
      var message = $('<h2></h2>');
      message.text('No posts available');
      $(container).append(message);
    } else {
      posts.forEach(function(post) {
        var postContainer = $('<div></div>');
        postContainer.addClass('post');

        var postHeading = $('<h3></h3>');
        var postLink = $('<a></a>');
        var postContent = $('<div></div>');
        var postInfo = $('<div></div>');
        var createdOn = $('<span></span>');
        var modifiedOn = $('<span></span>');
        var author = $('<span></span>');

        postLink.text(post.Title);
        postLink.attr('href', url + post.Id);

        postHeading.html(postLink);

        postContent.addClass('post-content');
        postContent.html(post.Content.substr(0, 100));

        postInfo.addClass('post-info');

        createdOn.text('Created On: ' + post.CreatedOn.split('T')[0]);
        //createdOn.addClass('post-info-right');

        postInfo.append(createdOn);

        if (post.ModifiedOn) {
          modifiedOn.text('Edited On: ' + post.ModifiedOn.split('T')[0]);
          modifiedOn.addClass('post-info-right');
          postInfo.append(modifiedOn);
        }
        

        postContainer.append(postHeading);
        postContainer.append(postContent);
        postContainer.append(postInfo);

        author.text('Author: ' + post.Author);
        author.addClass('post-info-right');
        postInfo.append(author);

        $(container).append(postContainer);
      });
    }
  }

  function renderLatestPosts(container)
  {
      var url = app.service.url + '/Posts/Top/5';
      app.ajaxRequester.get(url).then(function (data) {
          data.forEach(function (post) {
              var postTemplate = $('<h4></h4>');
              var postLink = $('<a></a>');
              postLink.attr('href', location.origin + '/Post/Details/' + post.Id);
              postLink.text(post.Title.substr(0, 30) + '...');
              postTemplate.append(postLink);
              $(container).append(postTemplate);
          });
      }, function (err) {
          console.error(err);
      });
  }

  function renderCategories(container) {
    var url = app.service.url + "/Category";
    app.ajaxRequester.get(url).then(function(data) {
      data.forEach(function(category) {
        var categoryTemplate = $('<div></div>');
        var categoryLink = $("<a></a>");
        categoryLink.attr('href', location.origin + '/Category/Details/' + category.Id);
        categoryLink.text(category.Title);
        var categoryHeading = $('<h3></h3>');
        categoryHeading.append(categoryLink);
        categoryTemplate.append(categoryHeading);
        $(container).append(categoryTemplate);
      });
    }, function(err) {
      console.error(err);
    });
  }

  function renderMessage(text, container) {
    $(container).text(text);
  }

  function renderPostDetails(post, container) {
      _renderPostInfo(post);
      _renderPostContent(post);
      _renderPostComments(post, '#post-comments');
      _renderPostTags(post);
  }

  function _renderPostInfo(post) {
      if (post['CreatedOn']) {
          var date = app.utils.formatDate(post['CreatedOn']);
          $('#createdOn').append(date);
      }
      if (post['ModifiedOn']) {
          var modified = app.utils.formatDate(post['ModifiedOn']);
          $('#modifiedOn').append(modified);
      } else {
          $('#modifiedOn').hide();
      }
      if (post['Author']) {
          $('#author').append(post['Author']);
      }
  }

  function _renderPostContent(post) {
      $('#post-content').append(post.Content);
  }

  function _renderPostTags(post) {
      var tagsData = post.Tags;
      var postTags = [];
      tagsData.forEach(function (tag) {
          postTags.push(tag.Title);
      });
      var tagsString = postTags.join(', ');
      $('#post-tags p').append(tagsString);
  }

  function _renderPostComments(post, container) {
      var comments = post.Comments;
      if (comments.length === 0) {
          var message = $('<p></p>');
          message.text('No comments available');
          message.addClass('text-warning');
          $(container).append(message);
      } else {
          comments.forEach(function (comment) {
              var commentTemplate = $('<div></div>');
              commentTemplate.append(comment.Content);
              $(container + '#post-comments').append(commentTemplate);
          });
      }
  }

  return {
    renderPosts: renderPosts,
    renderPostDetails: renderPostDetails,
    renderCategories: renderCategories,
    renderMessage: renderMessage,
    renderLatestPosts: renderLatestPosts
  };
})();