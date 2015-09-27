<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title><?php echo $pageTitle; ?></title>

    <!-- Bootstrap core CSS -->
    <link href="<?php echo BASE_URL; ?>/css/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    <?php echo (isset($customHeader) ? $customHeader : ""); ?>
    <?php
    if(isset($includeHeader)){
        require_once $includeHeader;
    }
    ?>
  </head>

  <body>
    <div class="container" style="padding-top: 30px">