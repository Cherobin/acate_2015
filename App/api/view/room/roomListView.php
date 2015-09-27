<?php
include_once 'api/view/header.php';
echo "<h2 class='text-center'>Lista de salas</h2>";
foreach ($list as $room): ?>
    <div class="col-md-4 col-lg-3">
        <h2><?php echo $room->name; ?></h2>
        <p>Quantidade de lugares: <?php echo $room->chairs; ?></p>
        <img class="img-thumbnail" src="<?php echo BASE_URL.'/'.$room->qrcode; ?>" />
        <p><a class="btn btn-default" href="<?php echo BASE_URL.'/agenda/'.$room->id.'/new'; ?>" role="button">Agendar horário</a></p>
    </div>
<?php endforeach;
include_once 'api/view/footer.php';