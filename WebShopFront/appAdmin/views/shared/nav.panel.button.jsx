const React = require('react');
const { useState, useEffect } = require('react');
const {Button} = require('react-bootstrap');

function NavPanelButton(props) {
    return (
        <div className='floating-button'>
            <Button className='btn login-button' onClick={props.showNavPanel}>
                <i className='bi bi-card-list' style={{ fontSize: '1.5rem' }}></i>
            </Button>
        </div>
    );
}

module.exports = NavPanelButton;