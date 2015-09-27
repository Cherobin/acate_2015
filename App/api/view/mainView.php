<?php
include_once 'api/view/header.php';
?>
<ul class="list-group">
    <a class="list-group-item" href="<?php echo BASE_URL; ?>/map">Mapa ACATE</a>
    <a class="list-group-item" href="<?php echo BASE_URL; ?>/company/new">Cadastrar Empresa</a>
    <a class="list-group-item" href="<?php echo BASE_URL; ?>/company/list">Listar Empresas</a>
    <a class="list-group-item" href="<?php echo BASE_URL; ?>/room/new">Cadastrar Salas</a>
    <a class="list-group-item" href="<?php echo BASE_URL; ?>/room/list">Listar Salas e Agenda</a>
    <a class="list-group-item" href="<?php echo BASE_URL; ?>/credits">Creditos</a>
</ul>
<?php
include_once 'api/view/footer.php';