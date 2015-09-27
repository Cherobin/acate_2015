<script src="<?php echo BASE_URL; ?>/js/moment.min.js"></script>
<script src="<?php echo BASE_URL; ?>/js/bootstrap-datetimepicker.min.js"></script>

<script type="text/javascript">
    <?php
    $dates = array(array(),array());
    foreach ($list as $agenda) {
        $dates[0][] = $agenda->dateStart;
        $dates[1][] = $agenda->dateFinish;
    }
    ?>
    var dateFinishs = [['<?php echo implode("','", $dates[0])?>'], ['<?php echo implode("','", $dates[1])?>']];


    $(function () {
        $('#datetimepicker1').datetimepicker({
            inline: true,
            sideBySide: true,
            stepping: 30
        });

        $('#datetimepicker2').datetimepicker({
            useCurrent: false,
            inline: true,
            sideBySide: true,
            stepping: 30,
        });

        for(var i = 0 ; i < dateFinishs[0].length; i++){
            var dateStart = moment(dateFinishs[0][i], "YYYY-MM-DD HH:mm:SS");
            var dateFinish = moment(dateFinishs[1][i], "YYYY-MM-DD HH:mm:SS");
            var vetor = [dateStart, dateFinish];
//            console.log(vetor);
//
//            $('#datetimepicker1').data("DateTimePicker").disabledTimeIntervals(vetor);
//            $('#datetimepicker2').data("DateTimePicker").disabledTimeIntervals(vetor);
        }

        $("#datetimepicker1").on("dp.change", function (e) { 
            $('#dateStart').val(moment(e.date).format("YYYY-MM-DD HH:mm:SS"));
            $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker2").on("dp.change", function (e) {
            $('#dateFinish').val(moment(e.date).format("YYYY-MM-DD HH:mm:SS"));
            $('#datetimepicker1').data("DateTimePicker").maxDate(e.date);
        });
    });
</script>