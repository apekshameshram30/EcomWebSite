import { Component } from '@angular/core';
import { EComService } from 'src/app/e.com.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
 username:string='';
 password:string='';

 constructor(private service:EComService){}

 login(): void{
  const data = {
    login:{
      username: this.username,
      password: this.password
    }
  };

   this.service.loginUser(data).subscribe(
    response=>{
      console.log(response)
      alert("Login Successfull")
    },
    error=>{
      console.log(error)
      alert("login fails")
    }
    
   )
 } 
}
