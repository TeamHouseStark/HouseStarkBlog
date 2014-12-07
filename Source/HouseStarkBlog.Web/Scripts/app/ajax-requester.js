var app = app || {};
app.ajaxRequester = (function() {
  function baseRequest(url, method, data) {
    var defer = Q.defer();

    $.ajax({
      url: url,
      method: method,
      contentType: 'application/json',
      data: JSON.stringify(data),
      success: function(data) {
        defer.resolve(data);
      },
      error: function(error) {
        defer.reject(error);
      }
    });

    return defer.promise;
  }

  function getRequest(url) {
    return baseRequest(url, 'GET', null);
  }

  function postRequest(url, data) {
    return baseRequest(url, 'POST', data);
  }

  function putRequest(url, data) {
    return baseRequest(url, 'PUT', data);
  }

  function deleteRequest(url) {
    return baseRequest(url, 'DELETE', null);
  }

  return {
    get: getRequest,
    post: postRequest,
    put: putRequest,
    delete: deleteRequest
  };

})();