chrome.runtime.onMessage.addListener(
  function(request, sender, sendResponse) {
      chrome.tabs.create({ url: "http://localhost:9927/Order/NewOrder"},
      function (tab) {
        chrome.tabs.onUpdated.addListener(function (tabId) {
            if (tabId == tab.id) {
                chrome.tabs.sendMessage(tabId, request);
            }
        });
      }); 
      sendResponse({ACK: true});
  });