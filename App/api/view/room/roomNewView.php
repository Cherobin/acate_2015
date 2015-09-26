<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Cadastro de salas</title>

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
            <form method="post" action="<?php echo BASE_URL.'/room/new'; ?>" enctype="multipart/form-data">
                <div class="form-group">
                    <label for="name">Nome</label>
                    <input type="text" name="name" class="form-control" id="name" placeholder="Nome da sala">
                </div>
                <div class="form-group">
                    <label for="chairs">Quantidade de lugares</label>
                    <input type="text" name="chairs" class="form-control" id="chairs" placeholder="Quantidade de lugares">
                </div>
                <input type="submit"  class="btn btn-default" value="Cadastrar" />
            </form>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/bootstrap.min.js"></script>
  </body>
</html>
