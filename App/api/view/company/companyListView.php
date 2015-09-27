<?php
include_once 'api/view/header.php';
foreach ($list as $agenda): ?>
    <div class="col-md-4 col-lg-3">
        <img class="img-thumbnail" src="<?php echo BASE_URL.'/'.$agenda->logo; ?>" />
        <h2><?php echo $agenda->name; ?></h2>
        <p><?php echo $agenda->description; ?></p>
        <img class="img-thumbnail" src="<?php echo BASE_URL.'/'.$agenda->qrcode; ?>" />
        <?php if($agenda->link != "") : ?>
            <p><a class="btn btn-default" href="<?php echo $agenda->link; ?>" role="button">Ir para</a></p>
        <?php endif; ?>
    </div>
<?php endforeach;
include_once 'api/view/footer.php';