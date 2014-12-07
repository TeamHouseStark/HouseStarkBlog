var app = app || {};

app.renderer = (function() {
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

        createdOn.text('Created on: ' + post.CreatedOn.split('T')[0]);
        //createdOn.addClass('post-info-right');

        postInfo.append(createdOn);

        if (post.ModifiedOn) {
          modifiedOn.text('Last edit: ' + post.ModifiedOn.split('T')[0]);
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
    console.log(post);
  }

  return {
    renderPosts: renderPosts,
    renderPostDetails: renderPostDetails,
    renderCategories: renderCategories,
    renderMessage: renderMessage
  };
})();