import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Item } from "../reactiveform/item";

@Injectable()

export class DataService {

  constructor(private http: HttpClient) { }

// **************service layer by diksha using HttpClient Angular4*****************************************************************************************************
  url = "http://localhost:55809/api/RegisterUsers/";

  //getAll User service method 
  public getAll(): Observable<Item[]> {
    return this.http.get(this.url);
  }

  // Add new User Service method
  public add(itemName): Observable<number> {
    debugger;
    console.log(itemName);
    return this.http.post(this.url, JSON.stringify(itemName));
  }

  //Update User service method
  public update(id: number, itemToUpdate: any): Observable<number> {
    debugger;
    return this.http.put(this.url + id, JSON.stringify(itemToUpdate));
  }

//getUser by Id but not yet used
  getItemById(itemId: string): Observable<Item> {
    return this.http.get(this.url + itemId);
  }

  //Delete User service method
  delete(id) {
    return this.http.delete(this.url + id, JSON.stringify(id));
  }

}
// *************End of code*************************************************************************************
