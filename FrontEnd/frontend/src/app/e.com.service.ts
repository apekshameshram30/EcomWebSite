import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EComService {

  constructor(private http:HttpClient) { }


 private baseUrl="https://localhost:7123/api/Value/";

  private loginUrl= "https://localhost:7123/api/Value/Login";
  private registerUrl="https://localhost:7123/api/Value/Registration";
  private getProductUrl="https://localhost:7123/api/Value/GetAllProducts";
  private getCountryUrl= "https://localhost:7123/api/Value/GetCountry";
  private getStateUrl="https://localhost:7123/api/Value/GetAllStates";
  
  loginUser(data:any):Observable<any>{
    return this.http.post<any>(this.loginUrl,data);
  }
  
  registerUser(data:any):Observable<any>{
    return this.http.post<any>(this.registerUrl,data);
  }

  getProduct():Observable<any>{
    return this.http.get<any>(this.getProductUrl);
  }
  
  getCountry():Observable<any[]>{
    return this.http.get<any[]>(this.getCountryUrl);
  }
  
  getStates():Observable<any[]>{
    return this.http.get<any[]>(this.getStateUrl)
  }

  getStateByCountryId(countryId:number):Observable<any[]>{
     return this.http.get<any[]>(`${this.baseUrl}GetStateByCountryId?id=${countryId}`);
  }
}

export interface RegisterDTO{
  firstname:string;
  lastname:string;
  email:string;
  usertype:string;
  dob:Date;
  mobile:number;
  address:string;
  zipcode:number;
  countryId:number;
  stateId:number;
  image:File
}

// export interface CountryDTO{
//   name:string;
// }

export interface StateByCountryId {
  id: number;
  stateName: string;
  countryId: number
}