/*function sleep(seconds) {
	var waitUntil = new Date().getTime() + seconds * 1000;
	while (new Date().getTime() < waitUntil) true;

}*/
function getData(id) {
	$.ajax({
		url: "/Sensor/SensorsLevels",
		type: "GET",
		data: {
			'id': id
		},
		success: function (data) {
			console.log(data);
			var usefulData = jQuery.parseJSON(data);
			for (var i = 0; i < usefulData.length; i++) {
				if (usefulData[i]["IsOn"]) {
					$("#level_" + usefulData[i]["Id"]).html(usefulData[i]["CurrentLevel"]);
					if (usefulData[i]["CurrentLevel"] < 100) {
						$("#status_" + usefulData[i]["Id"]).removeClass();
						$("#status_" + usefulData[i]["Id"]).addClass("spinner-grow text-success");
					} else if (100 <= usefulData[i]["CurrentLevel"] && usefulData[i]["CurrentLevel"] <= 200) {
							$("#status_" + usefulData[i]["Id"]).removeClass();
						$("#status_" + usefulData[i]["Id"]).addClass("spinner-grow text-warning");
					} else {
							$("#status_" + usefulData[i]["Id"]).removeClass();
						$("#status_" + usefulData[i]["Id"]).addClass("spinner-grow text-danger");
					}
				} else {
					$("#status_" + usefulData[i]["Id"]).removeClass();
					$("#status_" + usefulData[i]["Id"]).addClass("spinner-grow text-dark");

                }
			}
					},
		error: function () {
			console.log("ERROR");
		}
	});
}
function deleteSensor(id) {
	swal({
		  title: "Are you sure?",
		  text: "Once deleted, you will not be able to recover this sensor!",
		  icon: "warning",
		  buttons: true,
		  dangerMode: true,
		})
		.then((willDelete) => {
		  if (willDelete) {
			  $.ajax({
					url: "/Sensor/Delete",
					type : "POST",
					data : {
					'id' : id
					},
					success : function() {
					$( "#"+id ).remove();
					swal("Poof! Your Compte has been deleted!", {
					icon: "success",
					});
					}
			  });
		  } else {
		    swal("Your sensor is safe!");
		  }
		});
	
}
function changeState(id) {
	if ($("#onoff_" + id).text() == 'Turn On') {
		swal({
			title: "Are you sure?",
			text: "The sensor will be turned on !",
			icon: "warning",
			buttons: true,
			dangerMode: true,
		})
			.then((willDelete) => {
				if (willDelete) {
					$.ajax({
						url: "/Sensor/ChangeState",
						type: "POST",
						data: {
							'id': id
						},
						success: function () {
							$("#onoff_" + id).html('Turn Off');
							swal("You can turn it off again by clicking TURN OFF ", {
								icon: "success",
							});

						}
					});
				} else {
					swal("Your sensor is ON");

				}
			});
	} else {
		swal({
			title: "Are you sure?",
			text: "The sensor will be turned off !",
			icon: "warning",
			buttons: true,
			dangerMode: true,
		})
			.then((willDelete) => {
				if (willDelete) {
					$.ajax({
						url: "/Sensor/ChangeState",
						type: "POST",
						data: {
							'id': id
						},
						success: function () {
							$("#onoff_" + id).html('Turn On');
							swal("You can turn it on again by clicking TURN ON ", {
								icon: "success",
							});

						}
					});
				} else {
					swal("Your sensor is OFF");

				}
			});
    }
	

}
