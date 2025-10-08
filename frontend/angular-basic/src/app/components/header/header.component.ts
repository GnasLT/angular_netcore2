import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Router } from "@angular/router";

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    imports: [CommonModule],
    styleUrls: ['./header.component.css'],
    standalone: true
})

export class HeaderComponent {

    constructor(private router: Router) {}


    showlogindialog = false;
    
    login_action(): void{
        this.router.navigate(['/login']);

    }


}