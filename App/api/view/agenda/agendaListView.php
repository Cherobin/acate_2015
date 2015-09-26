<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Lista de horários</title>

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
            <?php //for ($i = 0; $i<10; $i++): $company = $list[0]; ?>
            <?php foreach ($list as $agenda): ?>
                <div class="col-md-4 col-lg-3">
                    
                    <h2><?php echo $agenda->owner; ?></h2>
                    <p><?php echo $agenda->dateStart; ?></p>
                    <p><?php echo $agenda->dateFinish; ?></p>
                </div>
            <?php endforeach; ?>
            <?php // endfor; ?>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/bootstrap.min.js"></script>
  </body>
</html>
