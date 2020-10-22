import { post } from './crud';
import IPaymentRequest from '../types/IPaymentRequest';

const baseUrl = '/api/v1/payment';

async function getDataSignature(paymentRequest: IPaymentRequest) {
    return await post(`${baseUrl}/data-signature`, paymentRequest);
};

export default {
    getDataSignature: getDataSignature,
}