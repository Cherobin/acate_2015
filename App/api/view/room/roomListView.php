<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Lista de salas</title>

    <!-- Bootstrap core CSS -->
    <link href="<?php echo BASE_URL; ?>/css/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>
    <div class="container">
        <div class="row">
            <?php foreach ($list as $room): ?>
                <div class="col-md-4 col-lg-3">
                    <h2><?php echo $room->name; ?></h2>
                    <p>Quantidade de lugares: <?php echo $room->chairs; ?></p>
                    <img class="img-thumbnail" src="<?php echo BASE_URL.'/'.$room->qrcode; ?>" />
                    <p><a class="btn btn-default" href="<?php echo BASE_URL.'/agenda/'.$room->id.'/new'; ?>" role="button">Agendar horário</a></p>
                </div>
            <?php endforeach; ?>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/bootstrap.min.js"></script>
  </body>
</html>
