$('#clock').countdown(final_date)
  .on('update.countdown', function (event) {
    var format = '%S';
    if (event.offset.totalMinutes > 0) {
      format = '%M:' + format;
    }
    if (event.offset.totalHours > 0) {
      format = '%H:' + format;
    }

    if (event.offset.totalHours > 0) {
      $(this).css('font-size', '2rem')
    }
    else if (event.offset.totalMinutes > 0) {
      $(this).css('font-size', '5rem')
    }
    else {
      $(this).css('font-size', '7rem')
      $("#countdown-card").removeClass("bg-medium").addClass("bg-danger").addClass("text-black");
    }
    $(this).html(event.strftime(format));
  })
  .on('finish.countdown', function (event) {
    $(this).html('Scheppern!')
      .parent().addClass('disabled');
    $(this).css('font-size', '3rem')
    setTimeout(location.reload.bind(location), 30000);
  });