import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { DataService } from "../services/data.service";
import { Item } from "./item";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
// ***************component**************************************************************************************
@Component({
  selector: 'app-reactiveform',
  templateUrl: './reactiveform.component.html',
  styleUrls: ['./reactiveform.component.css']
})
// **************Class******************************************************************************************************
export class ReaciveformComponent implements OnInit {

// ********code by diksha for create ,update and delete user/variable Intializations*************************************************************************************************
  id: number;
  res: any;
  myform: FormGroup;
  public values: Item[];
  itemIdToUpdate = null;
  itemData: number;
  statusCode: number;
  requestProcessing = false;
  modelDataMain: any;
  public modalRef: BsModalRef;

  constructor(private fb: FormBuilder, private _dataService: DataService, private modalService: BsModalService) { }

// ****ngOnInit()Hook method of interface OnInit************************************************************************************************************
  ngOnInit() {
  //reactive Form Validation
    this.myform = this.fb.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    })
    //call GetMethod for user
    this.getAll();

  }
// *********************************************************************************************************************************
  //get method User
  getAll() {
      this._dataService.getAll().subscribe(data => {
      this.requestProcessing = false;
      this.values = data;
      console.log(data);    
    })
      this.requestProcessing = true;
  }
// **************To open model for Edit************************************************************************************************
  
  public openModalForEdit(template: TemplateRef<any>, modelData: any) {
    this.modalRef = this.modalService.show(template);

    debugger;
    this.res = modelData;
    this.id = modelData.Id
    console.log(this.id);
    console.log(this.res);

  }

// *********************To open Modal for delete**********************************************************************************************

  public openModalforDelete(template: TemplateRef<any>, modelData1: any) {
    this.res = modelData1
    this.modalRef = this.modalService.show(template);
    console.log(this.modalRef);

  }

// **********************submit form method to create User by diksha**************************************************************************************************
  onCreate() {   
    let item = this.myform.value;
    console.log(item);
    debugger;
    this._dataService.add(item)
        .subscribe(data => {
          this.requestProcessing = false;
          this.itemData = data;
          console.log(data);
          this.getAll();
          this.backToCreateItem();     
        });
        this.requestProcessing = true;
  }
// ********************update form sumit method to update User by id by diksha************************************************************************

  updatePost(model: any) {
    debugger;
    this.modelDataMain = model;
    this.modelDataMain.Id = this.id;
    this._dataService.update(this.modelDataMain.Id, this.modelDataMain)
      .subscribe(
      data => {
        console.log(data);
         this.requestProcessing = false;
         window.location.reload();
         this.backToCreateItem();      
      });
    this.requestProcessing = true;
  }

// ***************delete User by id by diksha******************************************************************************************
  
  deletePost(model: any) {
    debugger;
    this.id = model.Id
    this._dataService.delete(this.id).subscribe(
      data => {
        this.requestProcessing = true;
        window.location.reload();
        console.log(data);
      });
  }

// ***************Perform preliminary processing configurations.**************************************************************************************
  
  preProcessConfigurations() {
    this.statusCode = null;
    this.requestProcessing = true;
  }
// **********to go bak to create method.********************************************************************************************************************

  backToCreateItem() {
    this.itemIdToUpdate = null;
    this.myform.reset();
  }
// ******Reactive forM Validation to show error using following getter properties.******************************************************************************************************
  get name() {
    return this.myform.get('name');
  }
  get email() {
    return this.myform.get('email');
  }

  get password() {
    return this.myform.get('password');
  }
 
}
// **************End of code**************************************************************************************************************