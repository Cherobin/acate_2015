<?php
$app->group('/company', function() use($app){
    $companyController = new CompanyController();
    
    $app->get('/list/json', function() use ($app, $companyController){
        header('Access-Control-Allow-Origin: *');
        $companys = $companyController->listAll();
        echo json_encode($companys);
    });
    
    $app->get('/:id/json', function($id) use ($app, $companyController){
        header('Access-Control-Allow-Origin: *');
        $company = $companyController->getById($id);
	$app->conn = null;
        echo json_encode($company);
    });
    
    $app->get('/list', function() use ($app, $companyController){
        $list = $companyController->listAll();
        $app->render("company/companyListView.php", array("list" => $list));
    });
    
    $app->get('/new', function() use ($app, $companyController){
        $app->render("company/companyNewView.php", array());
    });
    
    $app->post('/new', function() use ($app, $companyController){
        $post = $app->request->params ();
        $name = @$post['name'];
        $description = @$post['description'];
        $logo = @$_FILES['logo'];
        $link = @$post['link'];
        $posX = @$post['pos_x'];
        $posY = @$post['pos_y'];
        
        if(!empty($name) && !empty($description) && !empty($logo) && !empty($link) && !empty($posX) && !empty($posY)){
            $company = new Company();
            $company->name = $name;
            $company->description = $description;
            $company->link = $link;
            $company->posX = $posX;
            $company->posY = $posY;
            $companyController->insert($company, $logo);

	    $app->redirect("/company/list");
        }else{
            $app->pass();
        }
    });
});
