    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="<?php echo BASE_URL; ?>/js/bootstrap.min.js"></script>
    <?php echo (isset($customFooter) ? $customFooter : ""); ?>
    <?php
    if(isset($includeFooter)){
        require_once $includeFooter;
    }
    ?>
  </body>
</html>