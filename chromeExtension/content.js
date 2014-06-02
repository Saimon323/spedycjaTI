$(".contentRight").append("<button class='injection-button'>Wyślij dane z rozszerzenia</button>")

var getFormValue = function(name, values, child){
	var returnValue;
	values.each(function(i, value){
		if(!_.str.startsWith($(value).html(), name))
			return;
		if(child === "undefined" || child === null)
			returnValue = $(values[i+1]).text();
		else
			returnValue = $(values[i+1]).children(child).text();
	})
	return returnValue;
}

var values = $(".contentRight tbody td p")

var data= {
	Type: getFormValue("Rodzaj", values),
	Weight: getFormValue("Ciężar", values),
	Volume: getFormValue("Objętość", values),
	Price: getFormValue("Proponowana cena", values),
	VehicleType: getFormValue("Naczepa", values),
	From: getFormValue("Transport", values, "b"),
	End: getFormValue("Transport", values, "font")
}

$(".injection-button").click(function(){
	chrome.runtime.sendMessage({data: data}, function(response) {
	  console.log(response.ACK);
	});
});

