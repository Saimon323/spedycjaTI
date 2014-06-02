$(document).ready(function(){
	chrome.runtime.onMessage.addListener(
	  function(request, sender, sendResponse) {
		  $(".company").val(request.data.Company);
		  $(".name").val(request.data.Name);
		  $(".phone").val(request.data.Phone);
		  $(".area").val(request.data.Area);
	      sendResponse({ACK: true});
	  });
});