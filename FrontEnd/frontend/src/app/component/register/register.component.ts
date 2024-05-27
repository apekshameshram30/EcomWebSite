import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EComService, RegisterDTO } from 'src/app/e.com.service';
 

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
 
  registration: any = {};
  

  registerDto!:RegisterDTO;
  selectedFile: File | null = null;
  countries!: any[];
  countryId!: number;
  states!:any[];
  stateId!:number;

  imageUrl: string | ArrayBuffer | null = null;

 constructor(private router:Router, private service:EComService){}

ngOnInit(){
 this.getAllCountries();
 this.getAllStates();
 

}

getAllCountries(){
  this.service.getCountry().subscribe(countries=>
    this.countries=countries);
}

getAllStates(){
  this.service.getStates().subscribe(states => this.states =states);
}

onCountryChange(event:any):void {
 const countryId= event.value;
 this.service.getStateByCountryId(countryId).subscribe((states) =>
  this.states=states);
}


onFileSelected(event: any) {
  const file: File = event.target.files[0];
  if(file){
      this.selectedFile = file;
      const reader= new FileReader();
      reader.onload= ()=>{
        this.imageUrl = reader.result;
      };
      reader.readAsDataURL(file);
  }
 
  //console.log(file);
}

register():void{

  debugger
  const formData = new FormData();
  formData.append('profilePic', this.selectedFile || '');
  formData.append('registrationData', this.registration);
    
//   let formData = new FormData();
// formData.append('firstName', this.registrationData.firstName ?? '');
// formData.append('lastName', this.registrationData.lastName ?? '');
// formData.append('email', this.registrationData.email ?? '');
// formData.append('userType', this.registrationData.userType ?? '');
// formData.append('dob', this.registrationData.dob instanceof Date ? this.registrationData.dob.toISOString() : '');
// formData.append('mobile', this.registrationData.mobile ?? '');
// formData.append('address', this.registrationData.address ?? '');
// formData.append('zipcode', this.registrationData.zipcode?.toString() ?? '');
// if (this.registrationData.image) {
//   formData.append('image', this.registrationData.image, this.registrationData.image.name);
// }
// formData.append('stateId', this.registrationData.stateId?.toString() ?? '');
// formData.append('countryId', this.registrationData.countryId?.toString() ?? '');

// Now you can send `formData` to your backend

  // Now you can send `formData` to your backend
  

 this.service.registerUser(formData).subscribe({
  next:(response) =>{
    console.log(response)
    alert("Registration Successfull");
    this.redirectToLogin
  },
  error:(error)=>
     console.error(error) 
     
 });
}




redirectToLogin(){
  this.router.navigate(['/login']);
}

}

