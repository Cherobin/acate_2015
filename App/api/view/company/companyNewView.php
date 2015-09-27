<?php
include_once 'api/view/header.php';
?>
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
    <div class="row">
        <div class="form-group col-xs-6">
            <label for="pos_x">Posição horizontal</label>
            <input type="text" class="form-control" id="pos_x" name="pos_x" placeholder="Posição horizontal" />
        </div>
        <div class="form-group col-xs-6">
            <label for="pos_y">Posição vertical</label>
            <input type="text" class="form-control" id="pos_y" name="pos_y" placeholder="Posição vertical" />
        </div>
    </div>
    <div class="form-group">
        <label for="logo">Logo</label>
        <input type="file" value="logo" id="logo" name="logo" />
    </div>
    <input type="submit"  class="btn btn-default" value="Cadastrar" />
</form>
<?php
include_once 'api/view/footer.php';
?>
