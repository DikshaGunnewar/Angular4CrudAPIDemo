import { NgModule } from "@angular/core";
import { ReaciveformComponent } from "./reactiveform.component";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormRoutingModule } from "./reactiveform-routing.module";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
    declarations:[ReaciveformComponent],

    imports:[
        CommonModule,
        ReactiveFormRoutingModule,
        ReactiveFormsModule
    ],

    providers:[],

})
export class ReactiveformModule{}