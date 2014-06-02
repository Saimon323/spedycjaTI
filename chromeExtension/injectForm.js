chrome.runtime.onMessage.addListener(
    function(request, sender, sendResponse) {
        $("#oType").val(request.data.Type);
        $("#oWeight").val(parseFloat(request.data.Weight));
        $("#oVolume").val(parseFloat(request.data.Volume));
        $("#oPrice").val(parseFloat(request.data.Price));
        $("#lVehicleType").val(request.data.VehicleType);
        $("#oStartPoint").val(request.data.From);
        $("#oEndPoint").val(request.data.End);

        sendResponse({ACK: true});
    }
);