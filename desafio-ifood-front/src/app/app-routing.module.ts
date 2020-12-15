import { ProductDeleteComponent } from './components/product/product-delete/product-delete.component';
import { ProductUpdateComponent } from './components/product/product-update/product-update.component';
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./views/home/home.component";
import { ProductComponent } from "./views/product/product.component";
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { AuthenticationComponent } from "./components/template/authentication/authentication.component";
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './components/login/auth.guard';
import { MasterComponent } from './components/template/master/master.component';

const routes: Routes = [
  {
    path: "",
    component: MasterComponent,
    children:[
      {
        path: "",
        component: HomeComponent
      },
      {
        path: "products",
        component: ProductComponent
      },
      {
        path: "products/create",
        component: ProductCreateComponent
      },
      {
        path: "products/update/:id",
        component: ProductUpdateComponent
      },
      {
        path: "products/delete/:id",
        component: ProductDeleteComponent
      }
    ],
    canActivate: [AuthGuard]
  },
  {
    path: "",
    component: AuthenticationComponent,
    children:[
      { 
        path: "", 
        redirectTo: "login", 
        pathMatch: "full"
      },
      { 
        path: "login", 
        component: LoginComponent 
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
