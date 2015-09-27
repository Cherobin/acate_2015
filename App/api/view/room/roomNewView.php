<?php
include_once 'api/view/header.php';
?>
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
<?php
include_once 'api/view/footer.php';