<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Cadastro de empresa</title>

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
            <form method="post" action="<?php echo BASE_URL.'/company/new'; ?>" enctype="multipart/form-data">
                <div class="form-group">
                    <label for="name">Nome</label>
                    <input type="text" name="name" class="form-control" id="name" placeholder="Nome da empresa">
                </div>
                <div class="form-group">
                    <label for="description">Descrição</label>
                    <textarea name="description" class="form-control" id="description" rows="3" placeholder="Resumo sobre a empresa"></textarea>
                </div>
                <div class="form-group">
                    <label for="link">Link</label>
                    <input type="text" name="link" class="form-control" id="link" placeholder="Link do site">
                </div>
                <div class="form-group">
                    <label for="logo">Logo</label>
                    <input type="file" value="logo" id="logo" name="logo" />
                </div>
                <input type="submit"  class="btn btn-default" value="Cadastrar" />
            </form>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/bootstrap.min.js"></script>
  </body>
</html>
