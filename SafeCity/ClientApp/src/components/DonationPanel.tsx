import React, { useState } from 'react';
import IPaymentRequest from '../types/IPaymentRequest';
import paymentService from '../services/paymentService';

declare global {
    interface Window {
        LiqPayCheckoutCallback: Function;
        LiqPayCheckout: any;
    }
}

const DonationPanel = ({ projectId, projectName }: { projectId: number, projectName: string }) => {
    const [donation, setDonation] = useState<IPaymentRequest>({
        amount: '100',
        email: '',
        projectId,
        projectName
    });

    const handleChange = (name: string) => (e: any) => {
        setDonation({ ...donation, [name]: e.target.value });
    };

    const handleSubmit = (e: any) => {
        e.preventDefault();

        paymentService.getDataSignature(donation)
            .then((res: any) => {
                window.LiqPayCheckoutCallback = function () {
                    window.LiqPayCheckout.init({
                        data: res.data,
                        signature: res.signature,
                        embedTo: '#liqpay_checkout',
                        mode: 'popup', // embed || popup,
                        language: 'uk',
                    }).on('liqpay.callback', function (data: any) {
                        console.log(data.status);
                        console.log(data);
                    }).on('liqpay.ready', function (data: any) {
                        // ready
                    }).on('liqpay.close', function (data: any) {
                        // close
                    });
                };

                window.LiqPayCheckoutCallback();

            }).catch((err) => {
                console.log('failed to getDataSignature: ', err);
            });
    };

    return <div id='donate-p' className='donation-panel'>
        <div id='liqpay_checkout'></div>
        <div className='donation-tabs'>
            <div className='active'>Підтримати проект</div>
        </div>
        <form className='donation-body' onSubmit={handleSubmit}>
            <div className='form-group'>
                <h6 className='form-text text-muted'>Отримані кошти будуть безпосередньо спрямовані на реалізацію даного проекту.</h6>
            </div>
            <div className='form-group'>
                <label htmlFor='selectAmount'>
                    <small className='form-text text-muted'>Ви можете обрати бажану суму</small>
                </label>
                <select className='form-control isFocus' id='selectAmount'
                    onChange={handleChange('amount')}
                    defaultValue={100}>
                    <option disabled={true}>Выберите сумму</option>
                    <option value='100'>100</option>
                    <option value='300'>300</option>
                    <option value='500'>500</option>
                    <option value='1300'>1300</option>
                </select>
            </div>
            <div className='form-group'>
                <label htmlFor='amount'>
                    <small className='form-text text-muted'>Або вкажіть будь-яку іншу суму</small>
                </label>
                <input type='number' min='0'
                    id='amount'
                    value={donation.amount}
                    onChange={handleChange('amount')}
                    required
                    placeholder='Своя сумма'
                    className='form-control'></input>
            </div>
            <div className='form-group donation-info'>
                <label htmlFor='email'>
                    <small className='form-text text-muted'>Ваша пошта</small>
                </label>
                <input type='email'
                    id='email'
                    value={donation.email}
                    onChange={handleChange('email')}
                    placeholder='Email'
                    className='form-control'
                    required></input>
                <small id='emailHelp' className='form-text text-muted'>Ми не зберігаємо ваші персональні дані. Ваша пошта потрібна для того, щоб ви отримали звіт про витрачені кошти.</small>
            </div>
            <div className='form-group'>
                <div className='form-check form-check-inline'>
                    <input className='form-check-input' type='checkbox' name='agreeTerms' id='agreeTerms' required></input>
                    <label className='form-check-label' htmlFor='agreeTerms'>Згоден з <a download='' target='_top' href='https://fondvnimanie.ru/static/filename.pdf' className='with-pdf-preview'>оферетою</a></label>
                </div>
            </div>
            <button className='btn btn-default' type='submit'>Продовжити</button>
        </form>
    </div>
};

export default DonationPanel;