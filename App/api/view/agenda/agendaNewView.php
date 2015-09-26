<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Cadastro de reserva</title>

    <!-- Bootstrap core CSS -->
    <link href="<?php echo BASE_URL; ?>/css/bootstrap.min.css" rel="stylesheet">
    <link href="<?php echo BASE_URL; ?>/css/bootstrap-datetimepicker.min.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>
    <div class="container">
        <div class="row">
            <form method="post" action="<?php echo BASE_URL.'/agenda/'.$id.'/new'; ?>">
                <div class="form-group">
                    <label for="owner">Responsável</label>
                    <input type="text" name="owner" class="form-control" id="owner" placeholder="Nome do responsável">
                </div>
                <div class="col-xs-12">
                    <input type="text" name="dateStart" id="dateStart"  hidden="true" />
                    <div class="form-group">
                        <label for="name">Data início</label>
                        <div id="datetimepicker1"></div>
                    </div>
                </div>
                
                <div class="col-xs-12">
                    <input type='text' name='dateFinish' id='dateFinish' hidden="true" />
                    <div class="form-group">
                        <label for="name">Data término</label>
                        <div id="datetimepicker2"></div>
                    </div>
                </div>
                <input type="submit"  class="btn btn-default" value="Cadastrar" />
            </form>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/moment.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/bootstrap.min.js"></script>
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
                console.log(vetor);
                 
                $('#datetimepicker1').data("DateTimePicker").disabledTimeIntervals(vetor);
//                  $('#datetimepicker2').data("DateTimePicker").disabledTimeIntervals(vetor);
            }
            
            $("#datetimepicker1").on("dp.change", function (e) { 
                $('#dateStart').val(moment(e.date).format("YYYY-MM-DD HH:mm:SS"));
//                $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepicker2").on("dp.change", function (e) {
                $('#dateFinish').val(moment(e.date).format("YYYY-MM-DD HH:mm:SS"));
//                $('#datetimepicker1').data("DateTimePicker").maxDate(e.date);
            });
        });
    </script>
  </body>
</html>
