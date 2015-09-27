<?php
include_once 'api/view/header.php';
echo "<h2 class='text-center'>Lista de horários</h2>";
foreach ($list as $agenda):?>
    <div class="col-md-4 col-lg-3">

        <h2><?php echo $agenda->owner; ?></h2>
        <p><?php echo $agenda->dateStart; ?></p>
        <p><?php echo $agenda->dateFinish; ?></p>
    </div>
<?php endforeach;
include_once 'api/view/footer.php';
