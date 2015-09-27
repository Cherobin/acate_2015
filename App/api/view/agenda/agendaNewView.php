<?php
include_once 'api/view/header.php';
?>
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
<?php
include_once 'api/view/footer.php';