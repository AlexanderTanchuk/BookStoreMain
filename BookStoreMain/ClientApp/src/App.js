import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Authors from './components/Authors';
import Books from './components/Books';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/books' component={Books} />
    <Route path='/authors' component={Authors} />
  </Layout>
);
