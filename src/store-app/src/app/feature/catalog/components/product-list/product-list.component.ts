import { Component } from '@angular/core';
import { NavbarComponent } from "../../../../core/components/navbar/navbar.component";
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductFilter } from '@catalog/shared/model/product-filter';
import { ProductService } from '@catalog/shared/service/products.service';
import { Product } from '@catalog/shared/model/product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [NavbarComponent, RouterModule, CommonModule,ReactiveFormsModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  public products: Observable<Product[]>;

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private router: Router) { }

  ngOnInit(): void {
    const productFilter: ProductFilter = {} as ProductFilter;
    this.products = this.productService.getProducts(productFilter);
  }
}
