chrome.runtime.onMessage.addListener(
  function(request, sender, sendResponse) {
	  console.log(request); 
	  console.log(sender); 
	  console.log(sendResponse); 
	  console.log(request.data.Company); 
	  console.log(request.data.Nam); 
	  console.log(request.data.Phone); 
	  console.log(request.data.Area); 
	  
	  $("#oName").val(request.data.Company);
	  $("#oType").val(request.data.Name);
	  $("#oWeight").val(request.data.Phone);
	  $("#oVolume").val(request.data.Area);
      sendResponse({ACK: true});
  });

console.log("test inject")
$(document).ready(function(){
	console.log("ready")

});