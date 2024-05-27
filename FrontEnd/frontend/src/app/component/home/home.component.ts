import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EComService } from 'src/app/e.com.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private route:Router,private service:EComService){}


login(){
  this.route.navigate(['/login']);
}

register(){
  this.route.navigate(['/register']);
}


}
                  