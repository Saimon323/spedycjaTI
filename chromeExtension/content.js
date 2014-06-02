$(".contentRight").append("<button class='injection-button'>Wyślij dane z rozszerzenia</button>")

var getFormValue = function(name, values){
	var returnValue;
	values.each(function(i, value){
		if(!_.str.startsWith($(value).html(), name))
			return;
		returnValue = $(values[i+1]).text();
	})
	return returnValue;
}

var values = $(".contentRight tbody td p")

var data= {
	Company: getFormValue("Firma", values),
	Name: getFormValue("Imię", values),
	Phone: getFormValue("Telefon", values),
	Area: getFormValue("Wojewodztwo", values)
}

console.log(data);

$(".injection-button").click(function(){
	chrome.runtime.sendMessage({data: data}, function(response) {
	  console.log(response.ACK);
	});
});

