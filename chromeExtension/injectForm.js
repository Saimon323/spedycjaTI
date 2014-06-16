chrome.runtime.onMessage.addListener(
    function(request, sender, sendResponse) {
        $("#load_Name").val(request.data.LoadName);
        $("#load_LoadType").val(request.data.Type);
        $("#load_Weight").val(parseFloat(request.data.Weight));
        $("#load_Price").val(parseFloat(request.data.Price));
        $("#vehicle_Name").val(request.data.VehicleType);
        $("#route_StartPoint").val(request.data.From);
        $("#route_EndPoint").val(request.data.End);
        $("#customer_Name").val(request.data.ClientName);
        $("#customer_Surname").val(request.data.ClientLastName);
        $("#customer_Address").val(request.data.End);
        $("#customer_PhoneNumber").val(request.data.ClientPhone);
        $("#customer_Firm").val(request.data.ClientCompany);

        sendResponse({ACK: true});
    }
);