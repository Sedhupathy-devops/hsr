package com.emids.da.repository;

import com.emids.da.model.Account;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class AccountRepository extends AbstractRepository<Account> {

  @Override
  public Account findById(Long id) {
    return find(Account.class, id);
  }
}
