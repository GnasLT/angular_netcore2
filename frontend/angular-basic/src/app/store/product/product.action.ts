import { createAction, props } from "@ngrx/store";
import { Product } from "../../model/product";



export const loadingProduct = createAction('[product] Load Products')
export const loadingProductSuccess = createAction('[product] Load Success', props<{products : Product[]}>())
export const loadingProductFail = createAction('[product] Load Failure', props< {error : string}>())