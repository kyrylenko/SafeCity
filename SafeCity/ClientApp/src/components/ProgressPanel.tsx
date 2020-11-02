import React from 'react';

const calcPercentage = (raised: number, total: number): number => raised / total * 100;

const ProgressPanel = ({ total, raised, currency = 'uah' }: { total: number, raised: number, currency?: string }) => {
    return <div className='progress-panel'>
        <div>
            <strong>Збір коштів</strong>
        </div>
        <div className='progress-bar'>
            <div className='progress-overlap' style={{ width: `${calcPercentage(raised, total)}%` }}></div>
        </div>
        <div className='progress-numbers'>
            <div className='progress-left'>
                Зібрано:<span>{raised} {currency}.</span>
            </div>
            <div className='progress-right'>
                Усього потрібно:<span>{total} {currency}.</span>
            </div>
        </div>
    </div>
};


export default ProgressPanel;