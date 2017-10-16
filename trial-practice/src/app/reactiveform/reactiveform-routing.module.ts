import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ReaciveformComponent } from "./reactiveform.component";
const routes: Routes=[

     {path:'', component:ReaciveformComponent}
 ];
 @NgModule({
     imports:[RouterModule.forChild(routes)],
     exports:[RouterModule]
 })
 export class ReactiveFormRoutingModule{}
 